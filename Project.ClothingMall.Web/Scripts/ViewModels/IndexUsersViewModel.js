function IndexUsersViewModel(users) {
    var self = this;
    self.users = users;

    self.showDeleteModal = function (data,event) {
        self.sending = ko.observable(false);
        $.get($(event.target).attr('href'), function (d) {
            $('.body-content').prepend(d);
            $('#deleteModal').modal('show');
            ko.applyBindings(self, document.getElementById('deleteModal'));
        });
    };

    self.deleteUser = function (form) {
        self.sending(true);
        return true;
    };
};
