
var jsonModel = '{"tasks":[{"id": "1", "name":"Jason Alexander","tasks":[{"id": "2", "name": "George Costanza","tasks":[{"id": "3", "name":"Art Vandelay"}]}]},{"id": "4", "name":"Michael Richards","tasks":[{"id": "5", "name":"Cosmo Kramer","tasks":[{"id": "6", "name":"H.E. Pennypacker"},{"id": "7", "name":"Bob Sacamano"}]}]},{"id": "8", "name":"Jerry Seinfeld","tasks":[{"id": "9", "name":"Kel Varnsen"}]}]}';

function TaskViewModel() {

    var self = this;

    initialiseModel(self, jsonModel);
}

function Task(id, name, parentTask) {

    var self = this;

    self.Id = id;
    self.Name = name;
    self.parentTask = parentTask;
    self.tasks = ko.observableArray([]);

    self.addTask = function () {
        self.tasks.push(new Task(-1, "New Task", self));
    }

    //TODO: Fix delete function
    self.deleteTask = function (task) {
        self.tasks.remove(task);
    }

}

function initialiseModel(model, jsonModel) {
    parsedModel = JSON.parse(jsonModel);
    model.tasks = ko.observableArray([]);
    addTasks(model, parsedModel.tasks);
    console.log(model);
}

function addTasks(parentTask, tasks) {
    if (typeof tasks === "undefined")
        return;

    for (var i = 0; i < tasks.length; i++) {
        var employee = tasks[i];
        var employeeModel = new Task(employee.id, employee.name, parentTask);
        parentTask.tasks.push(employeeModel);
        addTasks(employeeModel, employee.tasks);
    }
}