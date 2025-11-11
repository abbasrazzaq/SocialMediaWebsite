import { useState } from 'react';
import { apiFetch } from '../services/api';
import { useLocation } from 'react-router-dom';

function AddPost() {
    const [postText, setPostText] = useState<string>('');

    const location = useLocation();
    const searchParams = new URLSearchParams(location.search);
    const myUserId: number = Number(searchParams.get('userId')) || 1;

    async function addPost() {
        const timestamp = new Date().toISOString();

        try {
            await apiFetch('api/userposts/addpost?userId=' + myUserId, {
                method: "POST",
                body: {
                    text: postText,
                    timestamp: timestamp
                }
            });

            alert('Added post');
        }
        catch (error) {
            alert('Post failed to add ' + error);
        }
    }

    return (
        <div>
            <h2>Add New Post</h2>
            <textarea
                value={postText}
                onChange={e => setPostText(e.target.value)}
                maxLength={500}
                rows={5}
                cols={50}
                placeholder="Write your post (max 500 characters)"
            />
            <p>{postText.length}/500 characters</p>
            <button onClick={() => addPost() }>Post</button>
        </div>
    );


}

export default AddPost;