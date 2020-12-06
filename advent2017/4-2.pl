#!/usr/bin/perl

$valid = 0;
$i = 0;

LINE: while(<>) {
  chomp;

  %phrases = ();
  $i++;
  print "$i $_";

  foreach $phrase (split /\s+/) {
    $phrase = join('', sort(split //, $phrase));
    if ($phrases{$phrase}) {
      print " INVALID: $phrase repeats\n";
      next LINE;
    }

    $phrases{$phrase} ++;
  }

  $valid++;
  print " valid=$valid\n";
}

#while(($phrase, $count) = each %phrases) {
#  $valid++ if $count == 1;
#}

print "valid: $valid\n";
