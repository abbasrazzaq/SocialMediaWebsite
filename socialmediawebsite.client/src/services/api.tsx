export async function apiFetch<T = unknown>(path: string,
    options: {
        method?: string;
        body?: any;
        headers?: Record<string, string>;
    } = {}
) : Promise<T> {

    let { method = 'GET', body, headers = {} } = options;

    let fetchBody: BodyInit | null = null;

    if (body && !(body instanceof FormData)) {
        headers = { "Content-Type": "application/json", ...headers };
        fetchBody = JSON.stringify(body);
    } else {
        fetchBody = body ?? null;
    }

    const response = await fetch(path, {
        method,
        headers,
        body: fetchBody
        // credentials: 'include' // uncomment if use cookie-based auth
    });

    if (response.status === 401) {
        // TODO: Show error popup / go to error page
        throw new Error('Unauthorized');
    }

    if (!response.ok) {
        throw new Error(`API call failed with status ${response.status}`);
    }

    return response.json() as Promise<T>;
}