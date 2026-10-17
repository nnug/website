---
layout: default
ref: home
---
{% assign chapters = site.data.chapters %}
<div class="row">
    <div class="jumbotron">
        <div class="row">
            <div class="col-md-3">
                <figure>
                    <img class="img-responsive" alt="Roy Osherove at NNUG Oslo" src="{{ '/assets/images/Roy-Osherove-at-NNUG-Oslo.jpeg' | relative_url }}"/>
                    <figcaption><a href="https://twitter.com/RoyOsherove">Roy Osherove</a> at NNUG Oslo.</figcaption>
                </figure>
            </div>
            <div class="col-md-9" markdown="1">

Norwegian .NET User Group - NNUG - is an independent user group for developers working with Microsoft .NET technologies. The purpose of NNUG is to share experience with .NET, give advice and focus on best practices. NNUG is aimed at developers and architects.

NNUG currently has the following chapters:
{% for chapter in chapters %}{% if forloop.last %} {{ site.data.i18n[page.lang].and }} {% elsif forloop.first == false %}, {% endif %}[{{ chapter.name }}](#{{ chapter.meetup }}){% endfor %}.
Is there no local chapter where you live? Why not start a new one?
[Read more about what it takes, and what is expected.]({{ '/en/start-a-chapter/' | relative_url }})

</div>
        </div>
    </div>
</div>

{% for chapter in chapters %}{% assign column = forloop.index0 | modulo: 4 %}
{% if column == 0 %}<div class="row">{% endif %}
{% include chapter-tile.html chapter=chapter %}
{% if column == 3 or forloop.last %}</div>{% endif %}
{% endfor %}
