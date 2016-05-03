$(document).ready(function () {
    // On click of an <a> that contains the attribute data-post
    $("a[data-post]").click(function(e) {
        e.preventDefault();

        // This is this..?
        var $this = $(this);

        // Get the message contained in data-post
        var message = $this.data("post");

        // If confirm is not selected, return
        if (message && !confirm(message))
            return;

        // Create and submit a new form that will delete the user
        var antiForgeryToken = $("#anti-forgery-form input");
        var antiForgeryInput = $("<input type='hidden' />")
            .attr("name", antiForgeryToken.attr("name"))
            .val(antiForgeryToken.val());

        $("<form>")
            .attr("method", "post")
            .attr("action", $this.attr("href"))
            .append(antiForgeryInput)
            .appendTo(document.body)
            .submit();
    });

    $("[data-slug]").each(function() {
        var $this = $(this);
        // Get the slug
        var $sendSlugFrom = $($this.data("slug"));

        // On each key press
        $sendSlugFrom.keyup(function() {
            // Get the slug
            var slug = $sendSlugFrom.val();

            // Replace all non-alphanumeric characters
            slug = slug.replace("/[^a-zA-Z0-9\s]\g", "");
            
            // Make lowercase
            slug = slug.toLowerCase();

            // Replace all spaces with '-'
            slug = slug.replace("/\s+/g", "-");

            // If final char is a '-', trim it
            if (slug.charAt(slug.length - 1) === "-") {
                slug = slug.substr(0, slug.length - 1);
            }

            // Return slug
            $this.val(slug);
        });
    });
});