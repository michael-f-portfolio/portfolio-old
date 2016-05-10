$(document).ready(function() {
    var words = [
        'awe inspiring',
        'exciting',
        'copywrited',
        'unoriginal',
        '0x7A31C7',
        'plagiarised',
        'far to complex for you to understand',
        '[missing text: please ignore]'
    ];
    var i = 0;

    setInterval(function() {
        $('#bullshit').fadeOut(function () {
                $(this).html(words[i = (i + 1) % words.length]).fadeIn();
        });
    }, 5000);
});