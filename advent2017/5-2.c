#include <stdio.h>
#include <stdlib.h>

#define PAGESIZE 64

int steps = 0;
int pages = 1;
int *offsets;
unsigned int loaded = 0;

// Load instruction. If instruction hasn't been read into memory,
// load it in by reading lines from stdin. When reading ends
// and the instruction is past the buffer, the program is done.
int load(int instruction) {
  char linebuffer[10];
  printf("loading %d\n", instruction);
  if (instruction > pages * PAGESIZE) {
    while (instruction > pages * PAGESIZE) {
      pages++;
    }
    printf("allocated %d pages for instruction #%d\n", pages, instruction);

    offsets = realloc(offsets, pages * PAGESIZE * sizeof(int));
  }

  while(loaded <= instruction) {
    if(fgets(linebuffer, 10, stdin)) {
      for(char i = 0; i < 10; i++) {
        if (linebuffer[i] == '\n') {
          linebuffer[i] = 0;
        }
      }

      printf("loaded line %s ", linebuffer);
      offsets[loaded] = atoi(linebuffer);
      printf("value %i\n", offsets[loaded]);
      loaded++;
    }
  }

  int offset = offsets[instruction];

  printf("offset: %d\n", offset);
  offsets[instruction] += offset >= 3 ? -1 : 1;

  return offset;
}

int main() {
  int offset = 0;

  offsets = malloc(PAGESIZE * sizeof(int));

  do {
    printf("offset %d -> ", offset);
    offset += load(offset);
    printf("%i\n ", offset);
    steps++;
  } while(offset >= 0 && offset <= loaded);

  printf("steps: %d\n", steps);
  return 0;
}
