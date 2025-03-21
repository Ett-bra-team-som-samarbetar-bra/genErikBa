﻿namespace Api.Controllers.Events;

public class EventCreateValidator : AbstractValidator<EventCreateDTO>
{
    public EventCreateValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(600);

        RuleFor(x => x.City)
            .NotEmpty()
            .MaximumLength(60);

        RuleFor(x => x.Address)
            .NotEmpty()
            .MaximumLength(60);

        RuleFor(x => x.StartTime)
            .NotEmpty();

        RuleFor(x => x.EndTime)
            .GreaterThan(x => x.StartTime);

        RuleFor(x => x.AccessType)
            .IsInEnum();

        RuleFor(x => x.ImagePath)
            .NotEmpty();

        RuleFor(x => x.TicketsMax)
            .GreaterThan(0)
            .When(x => x.AccessType != AccessType.Free || x.HasSeat);
            
        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0)
            .When(x => x.AccessType == AccessType.Paid)
            .WithMessage("Price is required for paid events");
    }
}

public class EventUpdateValidator : AbstractValidator<EventUpdateDTO>
{
    public EventUpdateValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(600);

        RuleFor(x => x.City)
            .NotEmpty()
            .MaximumLength(60);

        RuleFor(x => x.Address)
            .NotEmpty()
            .MaximumLength(60);

        RuleFor(x => x.StartTime)
            .NotEmpty();

        RuleFor(x => x.EndTime)
            .GreaterThan(x => x.StartTime);

        RuleFor(x => x.AccessType)
            .IsInEnum();
            
        RuleFor(x => x.ImagePath)
            .NotEmpty();

        RuleFor(x => x.TicketsMax)
          .GreaterThan(0)
          .When(x => x.AccessType != AccessType.Free || x.HasSeat);

        RuleFor(x => x.TicketsSold)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.TicketsSold)
            .LessThan(x => x.TicketsMax)
            .When(x => x.TicketsMax != null);
            
        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0)
            .When(x => x.AccessType == AccessType.Paid)
            .WithMessage("Price is required for paid events");
    }
}
