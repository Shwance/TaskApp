function TaskAppViewModel() {

    var self = this;
   
    initializeModel(self, jsonModel);

}

var jsonModel = '{"tasks": [{"id": 1, "name": "First Task", "description": "Task Description", "dueDate": "2017-01-12T12:22:42.7509841-08:00" , "completed": false }]}';

function initializeModel(model, jsonModel) {
    parsedModel = JSON.parse(jsonModel);
    model.tasks = ko.observableArray([]);
    addTasks(model, parsedModel.tasks);
};

function addTasks(parentModel, tasks) {
    if (typeof tasks === 'undefined')
        return;

    for (var i = 0; i < tasks.length; i++) {
        var task = tasks[i];
        var taskModel = new Task(task.Id, task.Name, task.Description, task.DueDate, task.Completed, parentModel);
        parentModel.tasks.push(taskModel);
        addTasks(taskModel, task.tasks);
    }
};

function Task(id, name, description, dueDate, completed, parentTask) {
    var self = this;
    self.Id = id;
    self.Name = name;
    self.Description = description;
    self.DueDate = dueDate;
    self.Completed = completed;
    self.tasks = ko.observableArray([]);
};