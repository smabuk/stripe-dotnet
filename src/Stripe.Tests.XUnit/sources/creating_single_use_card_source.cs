using FluentAssertions;
using Xunit;

namespace Stripe.Tests.Xunit
{
    public class creating_single_use_card_source
    {
        private StripeSource Source { get; set; }

        public creating_single_use_card_source()
        {
            var options = new StripeSourceCreateOptions
            {
                Type = StripeSourceType.Card,
                Usage = StripeSourceUsage.SingleUse,
                Token = "tok_visa",
            };

            Source = new StripeSourceService(Cache.ApiKey).Create(options);
        }

        [Fact]
        public void source_should_not_be_null()
        {
            Source.Should().NotBeNull();
            Source.Card.Should().NotBeNull();
            Source.Usage.Should().Be(StripeSourceUsage.SingleUse);
        }
    }
}
