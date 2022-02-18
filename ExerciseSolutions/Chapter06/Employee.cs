
using LaYumba.Functional;

namespace ExerciseSolutions.Chapter06;

public record Employee
(
   string Id,
   Option<WorkPermit> WorkPermit,

   DateTime JoinedOn,
   Option<DateTime> LeftOn
);
