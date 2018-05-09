function EditUsersViewModel(user) {
    var self = this;

    self.saveCompleted = ko.observable(false);
    self.sending = ko.observable(false);
    self.user = {
        userId: user.userId,
        userName: ko.observable(user.userName),
        userPassword: ko.observable(user.userPassword),
        status: ko.observable(user.status),
    };

    self.validateAndSave = function (form) {
        if (!$(form).valid())
            return false;
        self.sending(true);
        // include the anti forgery token
        self.user.__RequestVerificationToken = form[0].value;
        $.ajax({
            url:  'Edit',
            type: 'post',
            contentType: 'application/x-www-form-urlencoded',
            data: ko.toJS(self.user)
        })
        .success(self.successfulSave)
        .error(self.errorSave)
        .complete(function () { self.sending(false) });
    };

    self.successfulSave = function () {
        self.saveCompleted(true);

        $('.body-content').prepend('<div class="alert alert-success"><strong>Success!</strong> The user has been saved.</div>');
        setTimeout(function () {
                location.href = '../';
        }, 1000);
    };

    self.errorSave = function () {
        $('.body-content').prepend('<div class="alert alert-danger"><strong>Error!</strong> There was an error saving the user.</div>');
    };
}