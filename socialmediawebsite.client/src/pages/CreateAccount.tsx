import React from 'react';
import { apiFetch } from '../services/api';

interface CreateAccountData {
    username: string;
    // password: string;
    fullname: string;
    age: number;
    location: string;
    workplace: string;
    hometown: string;
    studiedAt: string;
}

function CreateAccount() {

    async function handleCreateAccount(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();

        const formData = new FormData(event.currentTarget);
        const createAccountData: CreateAccountData = {
            username: formData.get('username') as string,
            fullname: formData.get('fullname') as string,
            age: Number(formData.get('age')) || 18,
            location: formData.get('location') as string,
            workplace: formData.get('workplace') as string,
            hometown: formData.get('hometown') as string,
            studiedAt: formData.get('studiedAt') as string
        };

        try {
            await apiFetch<boolean>('api/UserProfile/createaccount', {
                method: 'POST',
                body: createAccountData
            });
        }
        catch (error) {
            console.error(error);
            alert('Account creation failed: ' + error);
        }
    }

    return (
        <form onSubmit={handleCreateAccount}>
            <h1>Create Account</h1>

            <label>
                <span>Username:</span>
                <input type="text" name="username" />
            </label>

            {/*<label>*/}
            {/*    <span>Password:</span>*/}
            {/*    <input type="password" name="password" />*/}
            {/*</label>*/}

            <label>
                <span>Fullname:</span>
                <input type="text" name="fullname"
            </label>

            <label>
                <span>Age:</span>
                <input type="number" name="age" />
            </label>

            <label>
                <span>Location:</span>
                {/*TODO: Have a drop down selection*/}
                <input type="text" name="location" />
            </label>

            <label>
                <span>Workplace:</span>
                <input type="text" name="workplace" />
            </label>

            <label>
                <span>Hometown:</span>
                {/*TODO: Have a drop down selection*/}
                <input type="text" name="hometown" />
            </label>

            <label>
                <span>Studied At:</span>
                { /*TODO: Have a drop down selection*/ }
                <input type="text" name="studiedAt" />
            </label>

            <button type="submit" id="createAccountBtn">Create Account</button>
        </form>
    );
}

export default CreateAccount;