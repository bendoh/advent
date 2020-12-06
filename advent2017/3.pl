#!/usr/bin/perl

use POSIX qw(floor abs);
use Data::Dumper qw(Dumper);

$input = shift @ARGV;

$x = $y = 0;
$xd = 1; $yd = 0;
@grid = ();
$s = 0;
$l = 1;

print "i=0 x=$x y=$y\n";

for($i = 1; $i < $input; $i++) {
  if ($i - $l > floor($s)) {
    $s+= .5;
    $l = $i;

    if ($xd == 1) {
      $yd = 1;
      $xd = 0;
    } elsif ($yd == 1) {
      $yd = 0;
      $xd = -1;
    } elsif ($xd == -1) {
      $yd = -1;
      $xd = 0;
    } else {
      $yd = 0;
      $xd = 1;
    }
  }

  $x += $xd;
  $y += $yd;

  print "i=$i x=$x y=$y xd=$xd yd=$yd s=$s\n";

}

print (abs($x) + abs($y)) . "\n";
