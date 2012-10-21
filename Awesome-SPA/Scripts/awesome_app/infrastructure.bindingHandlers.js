define(['knockout'], function (ko) {
    ko.bindingHandlers.popover = {
        init: function (element, valueAccessor) {
            var value = ko.utils.unwrapObservable(valueAccessor());
            $(element).popover({ trigger: 'hover', placement: 'bottom', html: true, title: '<b>' + value.user.username + '<b>', content: value.caption.text });
        },
        update: function (element, valueAccessor, allBindingsAccessor) {
            // Leave as before
        }
    };
})