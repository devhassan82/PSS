$(document).ready(function () {
    LeavePageQuestion();
});

function LeavePageQuestion() {
    //comment this for hide message confirmation
    window.addEventListener("beforeunload", function (e) {
       var confirmationMessage = "Exit message";
        e.returnValue = confirmationMessage;     // Gecko and Trident
        return confirmationMessage;              // Gecko and WebKit
    });

    window.addEventListener('unload', function (e) {
        App.BrowserClosed(e.currentTarget.Wisej.Core.session.id);
    });
}
