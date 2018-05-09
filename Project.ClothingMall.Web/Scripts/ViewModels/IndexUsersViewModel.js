function IndexUsersViewModel(users) {
    var self = this;
    self.users = users;

    self.showDeleteModal = function (data,event) {
        
        alert(event.target.nodeName);
        alert(data);
        self.sending = ko.observable(false);
        $.get($(event.target).attr('href'), function (d) {
            alert($('.body-content').html());
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
