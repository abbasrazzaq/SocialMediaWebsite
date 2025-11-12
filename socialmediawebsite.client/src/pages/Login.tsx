import { apiFetch } from '../services/api';
import React from 'react';

interface LoginInfo {
    username: string,
    password: string
}

function Login() {

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        const formData = new FormData(event.currentTarget);
        const loginInfo: LoginInfo = {
            username: formData.get('username') as string,
            password: formData.get('password') as string
        };

        const loginResult = await apiFetch<boolean>('api/Login/validatelogin', {
            method: 'POST',
            body: loginInfo
        });

        if (loginResult === true) {
            alert('login success');
        }
        else {
            alert('login fail');
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <h1>Login</h1>
            <label>
                <span>Username:</span>
                <input type="text" name="username" required />
            </label>
            <label>
                <span>Password:</span>
                <input type="password" name="password" required />
            </label>

            <button type="submit" id="loginBtn">Login</button>
        </form>
    );
}

export default Login;