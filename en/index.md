---
layout: home
ref: home
---
NNUG is an independent user group for developers working with Microsoft .NET technologies. The purpose of NNUG is to share experience with .NET, give advice and focus on best practices. NNUG is aimed at developers and architects.

NNUG currently has the following chapters:
{% for chapter in site.data.chapters %}{% if forloop.last %} {{ site.data.i18n[page.lang].and }} {% elsif forloop.first == false %}, {% endif %}[{{ chapter.name }}](#{{ chapter.meetup }}){% endfor %}.
Is there no local chapter where you live? Why not start a new one?
