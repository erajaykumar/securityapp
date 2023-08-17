import { UserProfile } from './user-profile';
import { SimpleClaim } from './simple-claim';

export class AuthContext {
  userProfile: UserProfile;

  get isAdmin() {
    return this.userProfile.role === 'admin';
  }
}
