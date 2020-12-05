#!/usr/bin/perl

use strict;

my $frequency = 0;
my %frequencies = ('0' => 1);
my @inputs = ();

while(<>) {
  chomp;
  push @inputs, $_;
}

for(my $loop = 0; $loop < 10000; $loop++) {
  foreach my $input (@inputs) {
    $frequency += $input;

    if ($frequencies{$frequency}) {
      print "FOUND $frequency TWICE (loop #$loop)\n";
      exit(0);
    }
    $frequencies{$frequency}++;
    print "$frequency\n";
  }
}
