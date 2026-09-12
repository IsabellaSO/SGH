import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Quartos } from './quartos';

describe('Quartos', () => {
  let component: Quartos;
  let fixture: ComponentFixture<Quartos>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Quartos],
    }).compileComponents();

    fixture = TestBed.createComponent(Quartos);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
