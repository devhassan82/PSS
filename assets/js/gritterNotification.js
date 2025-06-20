
$(function () {
    //Gritter notification
    $('#regular-notification').click(function () {
        //alert('asdasdas')
        $.gritter.add({
            title: 'This is a regular notice!',
            text: 'This will fade out after a certain amount of time. Vivamus eget tincidunt velit. Cum sociis natoque penatibus et <a href="ui_element.html#" style="color:#ccc">magnis dis parturient</a> montes, nascetur ridiculus mus.',
            image: 'img/user.jpg',
            sticky: false,
            time: ''
        });
        return false;
    });

    $('#sticky-notification').click(function () {

        var unique_id = $.gritter.add({
            title: 'This is a sticky notice!',
            text: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus eget tincidunt velit. Cum sociis natoque penatibus et <a href="ui_element.html#">magnis dis parturient</a> montes, nascetur ridiculus mus.',
            image: 'img/user.jpg',
            sticky: true,
            time: '',
            class_name: 'my-sticky-class'
        });

        // You can have it return a unique id, this can be used to manually remove it later using
        /*
        setTimeout(function(){

            $.gritter.remove(unique_id, {
                fade: true,
                speed: 'slow'
            });
                
        }, 6000)
        */

        return false;
    });

    $('#info-notification').click(function () {

        $.gritter.add({
            title: '<i class="fa fa-info-circle"></i> This is a info notification',
            text: 'This will fade out after a certain amount of time. Vivamus eget tincidunt velit. Cum sociis natoque penatibus et <a href="ui_element.html#" style="color:#ccc">magnis dis parturient</a> montes, nascetur ridiculus mus.',
            sticky: false,
            time: '',
            class_name: 'gritter-info'
        });
        return false;
    });

    $('#success-notification').click(function () {

        $.gritter.add({
            title: '<i class="fa fa-check-circle"></i> This is a success notification',
            text: 'This will fade out after a certain amount of time. Vivamus eget tincidunt velit. Cum sociis natoque penatibus et <a href="ui_element.html#">magnis dis parturient</a> montes, nascetur ridiculus mus.',
            sticky: false,
            time: '',
            class_name: 'gritter-success'
        });
        return false;
    });

    $('#warning-notification').click(function () {

        $.gritter.add({
            title: '<i class="fa fa-warning"></i> This is a warning notification!',
            text: 'This will fade out after a certain amount of time. Vivamus eget tincidunt velit. Cum sociis natoque penatibus et <a href="ui_element.html#" style="color:#ccc">magnis dis parturient</a> montes, nascetur ridiculus mus.',
            sticky: false,
            time: '',
            class_name: 'gritter-warning'
        });
        return false;
    });

    $('#danger-notification').click(function () {

        $.gritter.add({
            title: '<i class="fa fa-times-circle"></i> This is a error notification!',
            text: 'This will fade out after a certain amount of time. Vivamus eget tincidunt velit. Cum sociis natoque penatibus et <a href="ui_element.html#" style="color:#ccc">magnis dis parturient</a> montes, nascetur ridiculus mus.',
            sticky: false,
            time: '',
            class_name: 'gritter-danger'
        });
        return false;
    });

    $("#remove-all").click(function () {
        $.gritter.removeAll();
        return false;
    });

    //jQuery popup overlay
    $('#darkCustomModal').popup({
        pagecontainer: '.container',
        transition: 'all 0.3s'
    });


    $('#lightCustomModal').popup({
        pagecontainer: '.container',
        transition: 'all 0.3s'
    });

});