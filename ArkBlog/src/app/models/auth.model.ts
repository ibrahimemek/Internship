export interface LoginRequest {
  userName: string;
  userPassword: string;
}

export interface RegisterRequest {
  userName: string;
  userEmail: string;
  userPassword: string;
  userType?: string;
}

export interface AuthResponse {
  token: string;
  user: User;
  expiresIn: number;
}

export interface User {
  id: string;
  userName: string;
  userEmail: string;
  userType: string;
} 