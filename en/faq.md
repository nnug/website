---
layout: page
ref: faq
title: Frequently asked questions
---
# Frequently asked questions

## Where is NNUG?

NNUG currently has local chapters in {% for chapter in site.data.chapters %}{% if forloop.last and forloop.first == false %} and {% elsif forloop.first == false %}, {% endif %}{{ chapter.name | remove: 'NNUG ' }}{% endfor %}. You can find all the chapters on the [home page]({{ '/en/#chapters' | relative_url }}). There are also similar user groups around the world ([country/city] .NET User Group).

## What does NNUG offer?

NNUG holds evening meetups in each chapter, with local, national and/or international speakers. We focus on .NET, but also cover related technologies and processes. Topics vary between experience-based talks and talks about new technology. Meetups are announced in each chapter's group on Meetup.

## Does membership cost anything?

No! It costs nothing, and you have no obligations as a member. We are, however, very happy when many people turn up to our meetings.

## Is NNUG run by Microsoft?

No. NNUG is an independent volunteer organisation with no finances of its own. Our meetups depend on sponsors, usually companies that provide a venue and food.

## Why do I have to register?

You sign up for meetups on Meetup. One reason we ask you to sign up is that we often serve food, and we need to know how much to order. The number of sign-ups also tells us whether the venue is big enough, and which topics are popular. We do not share your contact information with anyone else.

## Do I have to attend NNUG after becoming a member?

No. We do, however, greatly appreciate it when many people attend the NNUG meetings. We put a lot of work into finding speakers and relevant topics, and a good turnout is a good sign that we have done a good job.

## Can I give a talk at NNUG?

Absolutely! We encourage all our members to give talks. You don't have to be a pro to contribute. We have everything from short 10-15 minute lightning talks to 1-2 hour sessions. We care a lot about NNUG being a local community where you can share your experience with people you don't normally work with. We believe this is exactly what makes NNUG a unique, independent meeting place for developers interested in .NET.

## How can you bring in international speakers when NNUG has no finances?

Support from sponsors sometimes makes it possible. Many speakers also want to visit user groups precisely because they know how much work and commitment we put into our local community, without being paid for it. Many are or have been involved in their own local user group, and often started their speaking career right there.

## Can I present our product at NNUG?

To some extent, but not directly. If your product is directly related to .NET and of general interest to our members, you can contact NNUG about giving a talk on the technology related to the product, and in some cases the product itself. What we do not like is covert advertising, whether in talks or in our Meetup groups. It will be removed immediately.
