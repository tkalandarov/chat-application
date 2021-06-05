"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build(),
    connectionId;

//Disable send button until connection is established
$("#sendButton").disabled = true;

connection.start().then(function () {
    $("#sendButton").disabled = false;
    connection.invoke('getConnectionId', $('#myUsername').val())
        .then(function (Id) {
            connectionId = Id;
        });
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("RecieveMessage", function (message, time) {
    $('.chat-wrapper.shown .chat').append('<div class="bubble other"><span class="message-text">' + message + ' </span>'
        + '<span class="message-time">' + time + '</span></div>');
    scrollToBottom();
})

var sendMessage = function (recipient) {
    event.preventDefault();

    var $text = $("#message-text").val();

    $.ajax({
        type: 'POST',
        url: '/Chat/SendMessage',
        data: { to: recipient, text: $text },
        cache: false,
        success: function () {
            $(".write textarea").val('');
            $(".chat-wrapper.shown .chat").append('<div class="bubble me"><span class="message-text">' + $text + ' </span>'
                + '<span class="message-time">' + getTimeNow() + '</span></div>');
            scrollToBottom();
        },
        error: function () {
            alert("Failed to send message!");
        }
    });
}

function getTimeNow() {
    return new Date().toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
}

function scrollToBottom() {
    $(".chat-wrapper.shown .chat").animate({ scrollTop: $('.chat-wrapper.shown .chat').prop("scrollHeight") }, 500);
}