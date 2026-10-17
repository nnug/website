website
=======

Source and content for www.nnug.no, published with [GitHub Pages](https://docs.github.com/pages) (Jekyll).

Editing
-------

- Pages are Markdown files in the repository root: `om-nnug.md`, `faq.md`,
  `foredragsholdere.md`, `ny-avdeling.md`. The front page is `index.md`.
- Chapters on the front page come from `_data/chapters.yml`. Add a logo to
  `assets/images` when adding a chapter.
- Shared page markup is in `_layouts` and `_includes`.
- English versions of every page are in `en/`. A Norwegian page and its
  translation share the same `ref` in their front matter, which the language
  switcher uses to link between them. Menu and button text for both
  languages is in `_data/i18n.yml`.

Old ASP.NET URLs (`/Home/About` etc.) redirect to the new pages.

Running locally
---------------

With Ruby installed:

    bundle install
    bundle exec jekyll serve

Or with Docker:

    docker run --rm -p 4000:4000 -v "$PWD:/srv/site" -w /srv/site ruby:3.3 bash -c "bundle install && bundle exec jekyll serve --host 0.0.0.0"

Then open http://localhost:4000.
