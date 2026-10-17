---
layout: home
ref: home
redirect_from:
  - /Home/
  - /Home/Index/
---
NNUG er en uavhengig brukergruppe for utviklere som jobber med Microsofts .NET teknologier. Formålet med NNUG er å utveksle erfaringer om .NET, gi råd og fokusere på best practises. Målgruppen for NNUG er utviklere og arkitekter.

NNUG er nå etablert med følgende avdelinger:
{% for chapter in site.data.chapters %}{% if forloop.last %} {{ site.data.i18n[page.lang].and }} {% elsif forloop.first == false %}, {% endif %}[{{ chapter.name }}](#{{ chapter.meetup }}){% endfor %}.
Er det ingen lokalavdeling der du bor? Hvorfor ikke starte en ny avdeling?
