import { useEffect, useState } from 'react';
import type { CSSProperties } from 'react';

interface Friend {
    username: string;
    fullname: string;
    // TODO: profilePicture: string
}

function FriendsList() {
    const [friendsList, setFriendsList] = useState<Friend[]>([]);

    useEffect(() => {
        async function loadFriendsList() {
            const response = await fetch('api/Friends', {
                method: "GET",
                headers: {
                    "Content-Type": "application/json"
                },
            });

            if (response.ok) {
                const data = await response.json();
                setFriendsList(data);
            }
        }

        loadFriendsList();
    }, []);

    return (
        <div>
            {friendsList.map((item) => (
                <li>
                    <div>
                        {item.username}
                    </div>
                    <span style={fullNameSpan}>{item.fullname}</span>
                </li>
            ))}
        </div>
    );
}

export default FriendsList;

const fullNameSpan: CSSProperties = {
    fontStyle: 'italic'

};