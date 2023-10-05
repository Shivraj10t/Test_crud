
const FirstName = document.getElementById('txt_firstName');
const LastName = document.getElementById('txt_LastName');
const Contact = document.getElementById('txt_Contact');
const dateOfBirth = document.getElementById('txt_DOB');

const Save_button = document.getElementById('btn_save')

Save_button.addEventListener("click", saveHandlear)

function saveHandlear() {
    
    const Post_data = {
        firstName: FirstName.value,
        LastName: LastName.value,
        Contact: Contact.value,
        DOB: dateOfBirth.value
    }
    
   
        fetch('/Student/SAVE_DATA', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
            },
            body: JSON.stringify(Post_data)
        }) 
    

}