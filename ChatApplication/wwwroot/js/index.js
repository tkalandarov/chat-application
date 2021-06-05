function loadChat(name) {
    $(".chat-wrapper.shown").removeClass("shown");
    $("#select-chat-div").hide();

    $chat = $('*[data-recipient="' + name + '"]');
    $chat.addClass("shown");
    scrollToBottom();
}

$(".write input").keyup(function (event) {
    if (event.keyCode === 13) {
        $("#btn-send").click();
    }
});

function sendMessage(recipient) {

    $text = $(".write input").val();
    $.ajax({
        type: 'POST',
        url: '/Chat/SendMessage',
        dataType: 'text',
        data: { to: recipient, text: $text },
        cache: false,
        success: function () {
            $(".write input").val('');
            $(".chat-wrapper.shown .chat").append('<div class="bubble me">' + $text + '</div>');
        },
        error: function () {
            alert("Server error!");
        }
    });
}