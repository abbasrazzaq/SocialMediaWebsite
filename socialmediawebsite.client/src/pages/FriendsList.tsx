import { useEffect, useState } from 'react';
import type { CSSProperties } from 'react';

interface Friend {
    username: string;
    fullname: string;
    // TODO: profilePicture: string
}

function FriendsList() {
    const [friendsList, setFriendsList] = useState<Friend[]>([]);

    async function removeFriend(userId: number, friendId: number) {
        const response = await fetch('api/Friends/removefriend', {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                userId: userId,
                friendId: friendId
            })
        });

        if (response.ok) {
            alert('remove success');
        }
        else {
            alert('remove failed');
        }

        setFriendsList(prev => prev.filter(friend => friend.friendId !== friendId))
    }

    useEffect(() => {
        async function loadFriendsList() {
            const response = await fetch('api/Friends/getfriends', {
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
        <ul>
            {friendsList.map((item) => (
                <li key={item.friendId}>
                    <div>
                        {item.username}
                    </div>
                    <span style={fullNameSpan}>{item.fullname}</span>
                    <button onClick={()=> removeFriend(1, item.friendId)}>Remove</button>
                </li>
            ))}
        </ul>
    );
}

export default FriendsList;

const fullNameSpan: CSSProperties = {
    fontStyle: 'italic'

};