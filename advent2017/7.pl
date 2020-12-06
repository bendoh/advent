use Data::Dumper qw(Dumper);

%parents = {};

while(<>) {
  if (/(.+) \((\d+)\)(?: -> (.+))?/) {
    print "$1 $2 $3\n";
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

print Dumper(\%programs, \%parents);
print "child=$child program=$program\n";

while ($parents{$program}) {
  print "program=$program\n";
  $program = $parents{$program};
}

print "child=$child program=$program\n";
