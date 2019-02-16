(function () {
    var $result = $("#result");
    $("form").submit(function () {
        switch (this.id)
        {
            case "addUserForm":
                var inputUserId = "",
                    inputUserName = $("#addUserForm .userName").val(),
                    inputUserDateOfBirth = $("#addUserForm .userDateOfBirth").val(),
                    inputAwardId = "",
                    inputAwardTitle = "",
                    inputConfirmationForRemoval = "",
                    inputListIndexOfUsers = "",
                    inputPathOfImage = "";
                $.ajax({
                    method: "POST",
                    url: "/UsersAndAwardsAjax",
                    data: {
                        userId: inputUserId,
                        userName: inputUserName,
                        userDateOfBirth: inputUserDateOfBirth,
                        awardId: inputAwardId,
                        awardTitle: inputAwardTitle,
                        actionPlan: this.id,
                        confirmationForRemoval: inputConfirmationForRemoval,
                        listIndexOfUsers: inputListIndexOfUsers,
                        pathOfImage: inputPathOfImage,
                    },
                    success: function (response) {
                        $result.html(response);
                    },
                })
                return false;
                break;
            case "deleteUserForm":
                var inputUserId = $("#deleteUserForm .userName").val(),
                    inputUserName = "",
                    inputUserDateOfBirth = "",
                    inputAwardId = "",
                    inputAwardTitle = "",
                    inputConfirmationForRemoval = "",
                    inputListIndexOfUsers = "",
                    inputPathOfImage = "";
                $.ajax({
                    method: "POST",
                    url: "/UsersAndAwardsAjax",
                    data: {
                        userId: inputUserId,
                        userName: inputUserName,
                        userDateOfBirth: inputUserDateOfBirth,
                        awardId: inputAwardId,
                        awardTitle: inputAwardTitle,
                        actionPlan: this.id,
                        confirmationForRemoval: inputConfirmationForRemoval,
                        listIndexOfUsers: inputListIndexOfUsers,
                        pathOfImage: inputPathOfImage,
                    },
                    success: function (response) {
                        $result.html(response);
                    },
                })
                return false;
                break;
            case "updateUserForm":
                var inputUserId = $("#updateUserForm .userId").val(),
                    inputUserName = $("#updateUserForm .userName").val(),
                    inputUserDateOfBirth = $("#updateUserForm .userDateOfBirth").val(),
                    inputAwardId = "",
                    inputAwardTitle = "",
                    inputConfirmationForRemoval = "",
                    inputListIndexOfUsers = "",
                    inputPathOfImage = "";
                $.ajax({
                    method: "POST",
                    url: "/UsersAndAwardsAjax",
                    data: {
                        userId: inputUserId,
                        userName: inputUserName,
                        userDateOfBirth: inputUserDateOfBirth,
                        awardId: inputAwardId,
                        awardTitle: inputAwardTitle,
                        actionPlan: this.id,
                        confirmationForRemoval: inputConfirmationForRemoval,
                        listIndexOfUsers: inputListIndexOfUsers,
                        pathOfImage: inputPathOfImage,
                    },
                    success: function (response) {
                        $result.html(response);
                    },
                })
                return false;
                break;
            case "showUsersForm":
                var inputUserId = "",
                    inputUserName = "",
                    inputUserDateOfBirth = "",
                    inputAwardId = "",
                    inputAwardTitle = "",
                    inputConfirmationForRemoval = "",
                    inputListIndexOfUsers = "",
                    inputPathOfImage = "";
                $.ajax({
                    method: "POST",
                    url: "/UsersAndAwardsAjax",
                    data: {
                        userId: inputUserId,
                        userName: inputUserName,
                        userDateOfBirth: inputUserDateOfBirth,
                        awardId: inputAwardId,
                        awardTitle: inputAwardTitle,
                        actionPlan: this.id,
                        confirmationForRemoval: inputConfirmationForRemoval,
                        listIndexOfUsers: inputListIndexOfUsers,
                        pathOfImage: inputPathOfImage,
                    },
                    success: function (response) {
                        $result.html(response);
                    },
                })
                return false;
                break;
            case "showAllUsersForm":
                var inputUserId = "",
                    inputUserName = "",
                    inputUserDateOfBirth = "",
                    inputAwardId = "",
                    inputAwardTitle = "",
                    inputConfirmationForRemoval = "",
                    inputListIndexOfUsers = "",
                    inputPathOfImage = "";
                $.ajax({
                    method: "POST",
                    url: "/UsersAndAwardsAjax",
                    data: {
                        userId: inputUserId,
                        userName: inputUserName,
                        userDateOfBirth: inputUserDateOfBirth,
                        awardId: inputAwardId,
                        awardTitle: inputAwardTitle,
                        actionPlan: this.id,
                        confirmationForRemoval: inputConfirmationForRemoval,
                        listIndexOfUsers: inputListIndexOfUsers,
                        pathOfImage: inputPathOfImage,
                    },
                    success: function (response) {
                        $result.html(response);
                    },
                })
                return false;
                break;
            case "addAwardForm":
                var inputUserId = "",
                    inputUserName = "",
                    inputUserDateOfBirth = "",
                    inputAwardId = "",
                    inputAwardTitle = $("#addAwardForm .awardTitle").val(),
                    inputConfirmationForRemoval = "",
                    inputListIndexOfUsers = "",
                    inputPathOfImage = "";
                $.ajax({
                    method: "POST",
                    url: "/UsersAndAwardsAjax",
                    data: {
                        userId: inputUserId,
                        userName: inputUserName,
                        userDateOfBirth: inputUserDateOfBirth,
                        awardId: inputAwardId,
                        awardTitle: inputAwardTitle,
                        actionPlan: this.id,
                        confirmationForRemoval: inputConfirmationForRemoval,
                        listIndexOfUsers: inputListIndexOfUsers,
                        pathOfImage: inputPathOfImage,
                    },
                    success: function (response) {
                        $result.html(response);
                    },
                })
                return false;
                break;
            case "deleteAwardForm":
                var inputUserId = "",
                    inputUserName = "",
                    inputUserDateOfBirth = "",
                    inputAwardId = $("#deleteAwardForm .awardId").val(),
                    inputAwardTitle = "",
                    inputConfirmationForRemoval = "",
                    inputListIndexOfUsers = "",
                    inputPathOfImage = "";
                $.ajax({
                    method: "POST",
                    url: "/UsersAndAwardsAjax",
                    data: {
                        userId: inputUserId,
                        userName: inputUserName,
                        userDateOfBirth: inputUserDateOfBirth,
                        awardId: inputAwardId,
                        awardTitle: inputAwardTitle,
                        actionPlan: this.id,
                        confirmationForRemoval: inputConfirmationForRemoval,
                        listIndexOfUsers: inputListIndexOfUsers,
                        pathOfImage: inputPathOfImage,
                    },
                    success: function (response) {

                        if (response.indexOf("To remove the award from the award list and custom lists?") > (-1)) {
                            var inputAwardId = response.slice(response.indexOf("?") + 2, response.indexOf(" ", response.indexOf("?") + 2));
                            var inputListIndexOfUsers = response.slice(response.indexOf(" ", response.indexOf("?") + 2) + 1, response.indexOf("</p>"));

                            if (confirm("the reward with the specified id was given to users, when it is removed, the reward will be removed from the list of users.")) {
                                var inputUserId = "",
                                    inputUserName = "",
                                    inputUserDateOfBirth = "",
                                    inputAwardTitle = "",
                                    inputConfirmationForRemoval = "true",
                                    inputPathOfImage = "";

                                $.ajax({
                                    method: "POST",
                                    url: "/UsersAndAwardsAjax",
                                    data: {
                                        userId: inputUserId,
                                        userName: inputUserName,
                                        userDateOfBirth: inputUserDateOfBirth,
                                        awardId: inputAwardId,
                                        awardTitle: inputAwardTitle,
                                        actionPlan: "deleteAwardForm",
                                        confirmationForRemoval: inputConfirmationForRemoval,
                                        listIndexOfUsers: inputListIndexOfUsers,
                                        pathOfImage: inputPathOfImage,
                                    },
                                    success: function (response) {
                                        $result.html(response);
                                    },
                                })
                            }
                        }
                        else {
                            $result.html(response);
                        }
                    }
                })
                return false;
                break;
            case "updateAwardForm":
                var inputUserId = "",
                    inputUserName = "",
                    inputUserDateOfBirth = "",
                    inputAwardId = $("#updateAwardForm .awardId").val(),
                    inputAwardTitle = $("#updateAwardForm .awardTitle").val(),
                    inputConfirmationForRemoval = "",
                    inputListIndexOfUsers = "",
                    inputPathOfImage = "";
                $.ajax({
                    method: "POST",
                    url: "/UsersAndAwardsAjax",
                    data: {
                        userId: inputUserId,
                        userName: inputUserName,
                        userDateOfBirth: inputUserDateOfBirth,
                        awardId: inputAwardId,
                        awardTitle: inputAwardTitle,
                        actionPlan: this.id,
                        confirmationForRemoval: inputConfirmationForRemoval,
                        listIndexOfUsers: inputListIndexOfUsers,
                        pathOfImage: inputPathOfImage,
                    },
                    success: function (response) {
                        $result.html(response);
                    },
                })
                return false;
                break;
            case "showAwardsForm":
                var inputUserId = "",
                    inputUserName = "",
                    inputUserDateOfBirth = "",
                    inputAwardId = "",
                    inputAwardTitle = "",
                    inputConfirmationForRemoval = "",
                    inputListIndexOfUsers = "",
                    inputPathOfImage = "";
                $.ajax({
                    method: "POST",
                    url: "/UsersAndAwardsAjax",
                    data: {
                        userId: inputUserId,
                        userName: inputUserName,
                        userDateOfBirth: inputUserDateOfBirth,
                        awardId: inputAwardId,
                        awardTitle: inputAwardTitle,
                        actionPlan: this.id,
                        confirmationForRemoval: inputConfirmationForRemoval,
                        listIndexOfUsers: inputListIndexOfUsers,
                        pathOfImage: inputPathOfImage,
                    },
                    success: function (response) {
                        $result.html(response);
                    },
                })
                return false;
                break;
            case "getAwardByIdForm":
                var inputUserId = "",
                    inputUserName = "",
                    inputUserDateOfBirth = "",
                    inputAwardId = $("#getAwardByIdForm .awardId").val(),
                    inputAwardTitle = "",
                    inputConfirmationForRemoval = "",
                    inputListIndexOfUsers = "",
                    inputPathOfImage = "";
                $.ajax({
                    method: "POST",
                    url: "/UsersAndAwardsAjax",
                    data: {
                        userId: inputUserId,
                        userName: inputUserName,
                        userDateOfBirth: inputUserDateOfBirth,
                        awardId: inputAwardId,
                        awardTitle: inputAwardTitle,
                        actionPlan: this.id,
                        confirmationForRemoval: inputConfirmationForRemoval,
                        listIndexOfUsers: inputListIndexOfUsers,
                        pathOfImage: inputPathOfImage,
                    },
                    success: function (response) {
                        $result.html(response);
                    },
                })
                return false;
                break;
            case "getAwardsIdByUsersIdForm":
                var inputUserId = $("#getAwardsIdByUsersIdForm .userId").val(),
                    inputUserName = "",
                    inputUserDateOfBirth = "",
                    inputAwardId = "",
                    inputAwardTitle = "",
                    inputConfirmationForRemoval = "",
                    inputListIndexOfUsers = "",
                    inputPathOfImage = "";
                $.ajax({
                    method: "POST",
                    url: "/UsersAndAwardsAjax",
                    data: {
                        userId: inputUserId,
                        userName: inputUserName,
                        userDateOfBirth: inputUserDateOfBirth,
                        awardId: inputAwardId,
                        awardTitle: inputAwardTitle,
                        actionPlan: this.id,
                        confirmationForRemoval: inputConfirmationForRemoval,
                        listIndexOfUsers: inputListIndexOfUsers,
                        pathOfImage: inputPathOfImage,
                    },
                    success: function (response) {
                        $result.html(response);
                    },
                })
                return false;
                break;
            case "toAwardUserForm":
                var inputUserId = $("#toAwardUserForm .userId").val(),
                    inputUserName = "",
                    inputUserDateOfBirth = "",
                    inputAwardId = $("#toAwardUserForm .awardId").val(),
                    inputAwardTitle = "",
                    inputConfirmationForRemoval = "",
                    inputListIndexOfUsers = "",
                    inputPathOfImage = "";
                $.ajax({
                    method: "POST",
                    url: "/UsersAndAwardsAjax",
                    data: {
                        userId: inputUserId,
                        userName: inputUserName,
                        userDateOfBirth: inputUserDateOfBirth,
                        awardId: inputAwardId,
                        awardTitle: inputAwardTitle,
                        actionPlan: this.id,
                        confirmationForRemoval: inputConfirmationForRemoval,
                        listIndexOfUsers: inputListIndexOfUsers,
                        pathOfImage: inputPathOfImage,
                    },
                    success: function (response) {
                        $result.html(response);
                    },
                })
                return false;
                break;
            case "addImageToUserByIdForm":
                var inputUserId = $("#addImaeToUserByIdForm .userId").val(),
                    inputUserName = "",
                    inputUserDateOfBirth = "",
                    inputAwardId = "",
                    inputAwardTitle = "",
                    inputConfirmationForRemoval = "",
                    inputListIndexOfUsers = "",
                    file = $("#imageAddImageToUserById .image").val();
                $.ajax({
                    method: "POST",
                    url: "/UsersAndAwardsAjax",
                    //processData: false,
                    //contentType: false, 
                    data: {
                        userId: inputUserId,
                        userName: inputUserName,
                        userDateOfBirth: inputUserDateOfBirth,
                        awardId: inputAwardId,
                        awardTitle: inputAwardTitle,
                        actionPlan: this.id,
                        confirmationForRemoval: inputConfirmationForRemoval,
                        listIndexOfUsers: inputListIndexOfUsers,
                        file: file,
                    },
                    success: function (response) {
                        $result.html(response);
                    },
                })
                return false;
                break;
        }
        $("#result").focus();
    })
})();