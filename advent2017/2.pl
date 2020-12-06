#!/usr/bin/perl

use Data::Dumper qw(Dumper);
use List::Util qw(min max);

my @rows;

$j = 0;
$sum = 0;
while(<>) {
  $rows[$j] = [ split /\s+/, $_ ];
  $sum += max(@{$rows[$j]}) - min(@{$rows[$j]});
  $j++;
}

print Dumper(\@rows);
print "sum=$sum\n";
