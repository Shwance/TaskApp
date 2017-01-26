
var node = function (config, parent) {

    var self = this;
    self.parent = parent;

    ko.mapping.fromJS(config, mappingOptions, self);
};


var mappingOptions = {
    'tasks': {
        create: function (options) {
            if (options.data !== null)
            {
                return new node(options.data, self);
            }
        }
    }
};

$(function () {

    $.getJSON("api/Task", function (data) {

    })
    .done(function (data) {
        var ViewModel = new node(data,null);
        ko.applyBindings(ViewModel);
    })
    .fail(function (err) {
        alert('error');
    });

});
