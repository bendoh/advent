
use Data::Dumper qw(Dumper);

%parents = {};

while(<>) {
  if (/(.+) \((\d+)\)(?: -> (.+))?/) {
    $program = $1;
    $programs{$program} = {
      'weight' => int $2,
      'children' => [ split(/\s*,\s*/, $3) ]
    };

    foreach $child (@{$programs{$1}{'children'}}) {
      $parents{$child} = $program;
    }
  }
}

#print Dumper(\%programs, \%parents);
print "program=$program\n";

while ($parents{$program}) {
  print "program=$program\n";
  $program = $parents{$program};
}

print "program=$program\n";

sub weigh {
  my ($program, $shift) = @_;
  my @children = @{$programs{$program}{'children'}};
  my $weight;
  local $childweight = 0;

  print "$depth $program:\n";
  print ("    " x $depth);
  if (@children) {
    my $total = 0;
    $weight = 0;

    foreach my $child (@children) {
      $weight = weigh($child, $depth + 1);
      if (!$childweight) {
        print "($weight) ";
        $childweight = $weight;
      }
      $total += $weight;
    }
    print "$total\n";
    return $total;
  }

  $weight = $programs{$program}{'weight'};

  print " $program($weight)";

  return $weight;
}

&weigh($program);
