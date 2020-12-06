#!/usr/bin/perl

$input = <>;
chomp $input;
@input = split '', $input;

$sum = 0;

for($i = 0; $i < @input; $i++) {
  $k = ($i + 1) > $#input ? 0 : $i + 1;

  print "i=$i k=$k {$input[$i]} {$input[$k]}\n";
  if($input[$i] == $input[$k]) {
    $sum += $input[$i];
  }
}

print $sum;


