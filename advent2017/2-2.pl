#!/usr/bin/perl

use Data::Dumper qw(Dumper);
use List::Util qw(min max);

my @rows;

$j = 0;
$sum = 0;
while(<>) {
  $rows[$j] = [ split /\s+/, $_ ];
  @line = @{$rows[$j]};

  OUTER: for($k = 0; $k < @line; $k++) {
    for($l = 0; $l < @line; $l++) {
      next if $k == $l;

      print "j=$j k=$k l=$l lk=${line[$k]} ll=${line[$l]} ";

      if($line[$k] > $line[$l] && $line[$k] % $line[$l] == 0) {
        $div = $line[$k] / $line[$l];
        $sum += $div;
        print "div=$div sum=$sum\n";
        last OUTER;
      }
      print "\n";
    }
  }

  $j++;
}

print Dumper(\@rows);
print "sum=$sum\n";
