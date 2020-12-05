#!/usr/bin/perl

use strict;

my $with_2 = 0;
my $with_3 = 0;

while(<>) {
  chomp;
  my @input = split(//, $_);
  my %characters = ();

  foreach my $char (@input) {
    $characters{$char}++;
  }

  my $has_2 = 0;
  my $has_3 = 0;

  while(my ($char, $count) = each %characters) {
    if ($count == 2) {
      $has_2 = 1;
    }
    elsif ($count == 3) {
      $has_3 = 1;
    }
  }

  if ($has_2) {
    $with_2 ++;
  } elsif ($has_3) {
    $with_3 ++;
  }

}

print "Checksum: $with_2 * $with_3 = " . ($with_2 * $with_3) . "\n";

