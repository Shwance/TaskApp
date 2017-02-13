
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
                var vm = new node(options.data, mappingOptions ,self);

                vm.name.subscribe(function (newValue) {

                    updateTask(vm)

                });

                return vm;
            }
        }
    }
};

function updateTask(vm)
{
    var task = {
        "Id": vm.id(),
        "Name": vm.name(),
        "Description": vm.description(),
        "DueDate": vm.dueDate(),
        "Completed": vm.completed()
    };

    $.ajax({
        url: 'api/Task',
        type: 'PUT',
        data: task
    });

}

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
