---
layout: default
redirect_from:
  - /Home/
  - /Home/Index/
---
{% assign chapters = site.data.chapters %}
<div class="row">
    <div class="jumbotron">
        <div class="row">
            <div class="col-md-3">
                <figure>
                    <img class="img-responsive" alt="Roy Osherove hos NNUG Oslo" src="{{ '/assets/images/Roy-Osherove-at-NNUG-Oslo.jpeg' | relative_url }}"/>
                    <figcaption><a href="https://twitter.com/RoyOsherove">Roy Osherove</a> hos NNUG Oslo.</figcaption>
                </figure>
            </div>
            <div class="col-md-9" markdown="1">

Norwegian .NET User Group - NNUG - er en uavhengig brukergruppe for utviklere som jobber med Microsofts .NET teknologier. Formålet med NNUG er å utveksle erfaringer om .NET, gi råd og fokusere på best practises. Målgruppen for NNUG er utviklere og arkitekter.

NNUG er nå etablert med følgende avdelinger:
{% for chapter in chapters %}{% if forloop.last %} og {% elsif forloop.first == false %}, {% endif %}[{{ chapter.name }}](#{{ chapter.meetup }}){% endfor %}.
Er det ingen lokalavdeling der du bor? Hvorfor ikke starte en ny avdeling?
[Les mer om hva som skal til, og hva som forventes.]({{ '/ny-avdeling/' | relative_url }})

</div>
        </div>
    </div>
</div>

{% for chapter in chapters %}{% assign column = forloop.index0 | modulo: 4 %}
{% if column == 0 %}<div class="row">{% endif %}
{% include chapter-tile.html chapter=chapter %}
{% if column == 3 or forloop.last %}</div>{% endif %}
{% endfor %}
