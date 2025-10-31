export interface Post {
  id: string;
  title: string;
  content: string;
  category: string;
  clickCount: number;
  author: User;
  createdAt: Date;
  updatedAt: Date;
}

export interface User {
  id: string;
  userName: string;
  userEmail: string;
  userType: string;
  posts: Post[];
}

export interface CreatePostRequest {
  title: string;
  content: string;
  category: string;
}

export interface UpdatePostRequest {
  id: string;
  title?: string;
  content?: string;
  category?: string;
} 