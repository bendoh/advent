while(<>) {
  push @list, int($_);
}

my $steps = 0;
sub step {
  local $i = shift,
        $offset = $list[$i];

  sub debug {
    print "$steps i=$i ";
    for(my $j = 0; $j < @list; $j++) {
      if ($j == $i) {
        print '(' . $list[$i] . ') '
      } else {
        print $list[$j] . ' ';
      }
    }
    print " offset=$offset\n";
  }

  if ($i >= @list || $i < 0) {
    return $i;
  }

  #debug();

  $steps++;

  $list[$i]++;

  return step($i+$offset);
}

step(0);

print $steps;
