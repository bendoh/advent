#!/usr/bin/perl

use List::Util qw(max);

@blocks = @ARGV;
@history = (join(' ', @blocks));
$step = 0;

print "$step: $history[0]\n";
sub step {
  $max = max @blocks;
  $bank = (grep { $blocks[$_] == $max } 0..$#blocks)[0];

  $blocks = $blocks[$bank];
  print "bank=$bank blocks=$blocks n=$#blocks\n";
  $blocks[$bank] = 0;
  for ($i = 1; $i <= $blocks; $i++) {
    $k = ($i + $bank) % @blocks;
    print "n=$#blocks i=$i k=$k\n";
    $blocks[$k]++;
    print join(' ', @blocks) . "\n";
  }

  $hash = join(' ', @blocks);
  $step++;

  print "$step: $hash\n";

  return if grep { $hash eq $_ } @history;
  push @history, $hash;

  step();
}

step();

