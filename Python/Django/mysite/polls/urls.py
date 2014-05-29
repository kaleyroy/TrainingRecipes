from django.conf.urls import patterns,url
from django.views.generic import DetailView,ListView

#from polls import views
from polls.models import Poll

urlpatterns = patterns('',
    url(r'^$',
        ListView.as_view(
            queryset = Poll.objects.order_by('-pub_date')[:5],
            context_object_name = 'latest_poll_list',
            template_name = 'polls/index.html'),
        name = 'index'),
    url(r'^(?P<pk>\d+)/$',
        DetailView.as_view(
            model = Poll,
            template_name = 'polls/detail.html'),
        name = 'detail'),
    url(r'^(?P<pk>\d+)/results/$',
        DetailView.as_view(
            model = Poll,
            template_name = 'polls/results.html'),
        name = 'results'),
    url(r'^(?P<poll_id>\d+)/vote/$','polls.views.vote',name = 'vote'),
    #eg: /polls/
    #url(r'^$', views.index, name = 'index'),
    #eg: /polls/1
    #url(r'^(?P<poll_id>\d+)/$', views.detail, name = 'detail'),
    #eg:
    #url(r'^(?P<poll_id>\d+)/results/$', views.results, name = 'results'),
    #eg:
    #url(r'^(?P<poll_id>\d+)/vote/$', views.vote, name = 'vote'),
)