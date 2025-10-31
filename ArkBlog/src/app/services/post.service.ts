import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { Post, CreatePostRequest, UpdatePostRequest } from '../models/post.model';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  constructor(private apiService: ApiService) { }

  getAllPosts(): Observable<Post[]> {
    return this.apiService.get<Post[]>('/Post');
  }

  getPostById(id: string): Observable<Post> {
    return this.apiService.get<Post>(`/Post/${id}`);
  }

  createPost(post: CreatePostRequest): Observable<Post> {
    return this.apiService.post<Post>('/Post', post);
  }

  updatePost(post: UpdatePostRequest): Observable<Post> {
    return this.apiService.put<Post>(`/Post/${post.id}`, post);
  }

  deletePost(id: string): Observable<void> {
    return this.apiService.delete<void>(`/Post/${id}`);
  }

  getPostsByCategory(category: string): Observable<Post[]> {
    return this.apiService.get<Post[]>(`/Post/category/${category}`);
  }
} 