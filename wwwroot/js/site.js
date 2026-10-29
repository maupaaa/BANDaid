// Sign in / Register dialogs.
// Every link with data-open-dialog="<id>" opens that <dialog>. Without JS the link
// simply goes to the standalone page (/Account/Login or /Account/Register).
(function () {
    function openDialog(id) {
        var dialog = document.getElementById(id);
        if (!dialog || typeof dialog.showModal !== "function") return false;

        document.querySelectorAll("dialog[open]").forEach(function (d) { d.close(); });
        dialog.showModal();
        return true;
    }

    document.addEventListener("click", function (event) {
        var opener = event.target.closest("[data-open-dialog]");
        if (opener) {
            if (openDialog(opener.getAttribute("data-open-dialog"))) {
                event.preventDefault();
            }
            return;
        }

        if (event.target.closest("[data-close-dialog]")) {
            var parent = event.target.closest("dialog");
            if (parent) parent.close();
            return;
        }

        // Click on the dimmed area around the card closes the dialog.
        if (event.target.tagName === "DIALOG" && event.target.classList.contains("auth-dialog")) {
            event.target.close();
        }
    });
})();
