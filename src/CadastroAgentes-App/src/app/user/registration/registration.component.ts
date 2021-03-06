import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/_models/User';
import { AuthService } from 'src/app/_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  registerForm: FormGroup;
  user: User;

  constructor(private authService: AuthService,
              private router: Router,
              public fb: FormBuilder,
              private toastr: ToastrService) {
  }

  ngOnInit() {
    this.validation();
  }

  validation() {
    this.registerForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      passwords: this.fb.group({
        password: ['', [Validators.required, Validators.minLength(4)]],
        confirmPassword: ['', Validators.required]
      }, { validator : this.compararSenha})
    });
  }

  compararSenha(fb: FormGroup) {
    const confirmPasswordCtrl = fb.get('confirmPassword');

    if (confirmPasswordCtrl.errors == null || 'mismatch' in confirmPasswordCtrl.errors) {
      if (fb.get('password').value !== confirmPasswordCtrl.value) {
        confirmPasswordCtrl.setErrors({mismatch: true});
      } else {
        confirmPasswordCtrl.setErrors(null);
       }

    }
  }

  cadastrarUsuario() {
    const userCadastro = {password: this.registerForm.get('passwords.password').value,
      confirmpassword: this.registerForm.get('passwords.password').value,
      email: this.registerForm.get('email').value};

    this.authService.register(userCadastro).subscribe(
      () => {
        this.router.navigate(['/user/login']);
        this.toastr.success('Cadastro realizado');
      }, error => {
        const erro = error.error;

        erro.forEach(element => {
          switch (element.code) {
            case 'DuplicateUserName':
              this.toastr.error('Cadastro já existe');
              break;
            default:
              this.toastr.error(`Erro no cadastro. Code: ${element.description}`);
              break;
          }
        });
      }
    );
  }

}
