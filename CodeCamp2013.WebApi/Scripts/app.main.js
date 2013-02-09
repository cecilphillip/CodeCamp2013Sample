; (function(window, app, ko, $, undefined) {
    $('#btnNew').on('click', function(e) {
        e.preventDefault();

    });
    var eventList = new app.vm.EventsList();
    eventList.loadEvents();
    ko.applyBindings(eventList);

}(window, window.app, ko, jQuery));