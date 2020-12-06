#!/usr/bin/perl

use POSIX qw(floor abs);
use Data::Dumper qw(Dumper);

$input = shift @ARGV;

$x = $y = 0;
$xd = 1; $yd = 0;
$s = 0;
$l = 0;

%grid = ();
$grid{0}{0} = 1;

print "i=0 x=$x y=$y\n";

$i = 0;
do {
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

  $grid{$x}{$y} =
    $grid{$x-1}{$y-1} + $grid{$x}{$y-1} + $grid{$x+1}{$y-1} +
    $grid{$x-1}{$y} + 0 + $grid{$x+1}{$y} +
    $grid{$x-1}{$y+1} + $grid{$x}{$y+1} + $grid{$x+1}{$y+1};

  print "i=$i x=$x y=$y xd=$xd yd=$yd s=$s val=$grid{$x}{$y}\n";
  $i++;
}
while ($input > $grid{$x}{$y});

print $i;
