#!/usr/bin/perl

$input = <>;
chomp $input;
@input = split '', $input;

$sum = 0;

for($i = 0; $i < @input; $i++) {
  $k = $i + @input / 2;

  if ($k >= @input) {
    $k -= @input;
  }

  print "i=$i k=$k {$input[$i]} {$input[$k]}\n";
  if($input[$i] == $input[$k]) {
    $sum += $input[$i];
  }
}

print $sum;

