import { useEffect, useState } from 'react';
import type { CSSProperties } from 'react';

interface UserProfile {
    username: string;
    fullname: string;
    age: number;
    location: string;
    workplace: string;
    hometown: string;
    studiedAt: string;
}

function Profile() {
    const [userProfile, setUserProfile] = useState<UserProfile>(null);

    useEffect(() => {
        async function loadUserProfile() {
            const response = await fetch('api/userprofile/getprofileinfo',
                {
                    method: "GET",
                    headers: { "Content-Type": "application/json" },
                    body: null
                });

            if (response.ok) {
                const data = await response.json();
                setUserProfile(data);

            }
        }

        loadUserProfile();

    }, [userProfile]);

    const contents = userProfile === null
        ? <p>Loading...</p>
        : <div>
            <div style={profileDiv}>
                <h1>User Profile</h1>
                <label style={profileDivLabel}>
                    <span style={profileDivSpan}>Username</span>
                    <span style={profileDivSpan}>{userProfile.username}</span>
                </label>
            </div>

            <div style={profileDiv}>
                <h2>Bio</h2>

                <label style={profileDivLabel}>
                    <span style={profileDivSpan}>Name:</span>
                    <span style={profileDivSpan}>{userProfile.fullname}</span>
                </label>

                <label style={profileDivLabel}>
                    <span style={profileDivSpan}>Age:</span>
                    <span style={profileDivSpan}>{userProfile.age}</span>
                </label>

                <label style={profileDivLabel}>
                    <span style={profileDivSpan}>Lives:</span>
                    <span style={profileDivSpan}>{userProfile.location}</span>
                </label>

                <label style={profileDivLabel}>
                    <span style={profileDivSpan}>Workplace:</span>
                    <span style={profileDivSpan}>{userProfile.workplace}</span>
                </label>

                <label style={profileDivLabel}>
                    <span style={profileDivSpan}>From:</span>
                    <span style={profileDivSpan}>{userProfile.hometown}</span>
                </label>

                <label style={profileDivLabel}>
                    <span style={profileDivSpan}>Studied at:</span>
                    <span style={profileDivSpan}>{userProfile.studiedAt}</span>
                </label>
            </div>
        </div>;

    return (
        <div>
            {contents}
        </div>   
    );
}

export default Profile;


const profileDiv: CSSProperties = {
    color: 'black'
};

const profileDivLabel: CSSProperties = {
    display: 'flex'
};

const profileDivSpan: CSSProperties = {
    display: 'flex',
    maxWidth: '250px',
    padding: '24px',
};