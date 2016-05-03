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
        $("<form>")
            .attr("method", "post")
            .attr("action", $this.attr("href"))
            .appendTo(document.body)
            .submit();
    });
});