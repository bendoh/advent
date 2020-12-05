#!/usr/bin/perl

use strict;

my $frequency = 0;

while(<>) {
  chomp;
  $frequency += $_;
  print "$frequency\n";
}

print $frequency;
