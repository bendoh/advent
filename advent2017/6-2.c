#include <stdio.h>
#include <stdlib.h>

unsigned short *blocks;
unsigned short nblocks;
unsigned short **history;
unsigned short steps = 0;

unsigned int step() {
  unsigned short idx = 1, j;
  unsigned int i;
  unsigned short max, bank;
  unsigned short *hash = history[steps];

  printf("ref: %d\n", (int) hash);
  for(i = 0; i < nblocks; i++) {
    hash[i] = blocks[i];
    if(blocks[i] > max) {
      max = blocks[i];
      bank = i;
    }
  }

  for(i = 0; i < steps; i++) {
    for(j = 0; j < nblocks; j++) {
      if(history[i * nblocks][j] != hash[j]) {
        break;
      }
    }
    if(j == nblocks) {
      return i;
    }
  }

  blocks[bank] = 0;

  for(idx = 1; idx <= max; idx++) {
    blocks[(idx + bank) % nblocks]++;
  }

  steps++;
  return step();
}

int main(int argc, char **argv) {
  nblocks = argc;
  blocks = malloc(nblocks * sizeof(short));
  history = malloc(nblocks * sizeof(short) * 20000 * 10);

  if(!history) {
    printf("no memory :(\n");
    return 1;
  }

  unsigned short i = 0;

  for(i = 0; i < argc; i++) {
    blocks[i] = atoi(argv[1+i]);
  }

  unsigned int found = step();

  printf("steps: %d   found: %d   diff: %d", steps, found, steps - found);

  return 0;
}
